using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Web.Entities;

namespace Web.Converter
{
    public static class OfxConverter
    {
        private static readonly string nodeExpression = @"<(?'tag'.+?)>(?(.*?</\k<tag>>)(?'value'.*?)(?'closingTag'</\k<tag>>)|(?'value'[^<]+))";
        private static readonly string headerExpression = "OFXHEADER:(?'header'.*)DATA:(?'data'.*)VERSION:(?'version'.*)SECURITY:(?'security'.*)ENCODING:(?'encoding'.*)CHARSET:(?'charset'.*)COMPRESSION:(?'compression'.*)OLDFILEUID:(?'oldFile'.*)NEWFILEUID:(?'newFile'[^<]*)";

        public static OfxFile Convert(MemoryStream ms, string fileName = "")
        {
			var ofxFile = new OfxFile();
			
			var text = GetString(ms);
			ofxFile.Header = GetOfxHeader(text);
			ofxFile.Info = GetOfxInfo(text);
			ofxFile.FileName = fileName;

			return ofxFile;
		}

		private static string GetString(MemoryStream ms)
        {
            using TextReader tr = new StreamReader(ms);
            return tr.ReadToEnd();
        }

		private static OfxHeader GetOfxHeader(string txt)
		{
			var infos = Regex.Matches(txt, headerExpression, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);

			return new OfxHeader()
			{
				Header = infos[0].Groups["header"].Value.Trim(),
				Data = infos[0].Groups["data"].Value.Trim(),
				Version = infos[0].Groups["version"].Value.Trim(),
				Security = infos[0].Groups["security"].Value.Trim(),
				Encoding = infos[0].Groups["encoding"].Value.Trim(),
				Charset = infos[0].Groups["charset"].Value.Trim(),
				Compression = infos[0].Groups["compression"].Value.Trim(),
				OldFileUID = infos[0].Groups["oldFile"].Value.Trim(),
				NewFileUID = infos[0].Groups["newFile"].Value.Trim(),
			};
		}

		private static OfxInfo GetOfxInfo(string text)
        {
			 // Use Regular Expression to get the first node of SGML
			var matches = Regex.Matches(text, nodeExpression, RegexOptions.Multiline | RegexOptions.Singleline);

			var root = new OfxNode
			{
				Name = matches[0].Groups["tag"].Value,
				Value = matches[0].Groups["value"].Value,
				ClosingTag = matches[0].Groups["closingTag"].Success
			};

			// Get children of SGML using regular expression recursively
			root.Children = GetChildren(root);

			//Convert object to XML before deserialize 
			XmlSerializer serializer = new XmlSerializer(typeof(OfxInfo));
            using TextReader reader = new StringReader(root.ToXml());
            return (OfxInfo)serializer.Deserialize(reader);
        }

		private static List<OfxNode> GetChildren(OfxNode node)
		{
			var nodes = new List<OfxNode>();

			if (!node.ClosingTag)
				return nodes;

			var matches = Regex.Matches(node.Value, nodeExpression, RegexOptions.Multiline | RegexOptions.Singleline);

			for (var i = 0; i < matches.Count; i++)
			{
				var newNode = new OfxNode
				{
					Name = matches[i].Groups["tag"].Value,
					Value = matches[i].Groups["value"].Value.Trim(),
					ClosingTag = matches[i].Groups["closingTag"].Success
				};

				newNode.Children.AddRange(GetChildren(newNode));
				nodes.Add(newNode);
			}

			return nodes;
		}

	}
}

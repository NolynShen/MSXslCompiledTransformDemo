using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Xsl;


namespace MSXslCompiler
{
    class Program
    {
        private const string sourceFile = @"./Resources/books.xml";
        private const string stylesheet = @"./Resources/output.xsl";
        private const string outputFile = @"./Resources/output.html";

        static void Main(string[] args)
        {
            
            // Enable XSLT debugging.  
            XslCompiledTransform xslt = new XslCompiledTransform(true);
            
            XsltSettings settings = new XsltSettings();
            settings.EnableScript = true;

            //XmlSecureResolver resolver = new XmlSecureResolver();

            // Compile the style sheet.  
            xslt.Load(stylesheet,settings,null) ;

            // Execute the XSLT transform.  
            //FileStream outputStream = new FileStream(outputFile, FileMode.Append);
            using (var outputStream = new FileStream(outputFile,FileMode.Append))
            {
                xslt.Transform(sourceFile, null, outputStream);
            }
              
           
        }
    }
}

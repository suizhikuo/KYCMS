namespace Ky.BLL
{
    using Microsoft.CSharp;
    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Text;
    using System.Web.Services.Description;

    public class WebServiceHelper
    {
        private Assembly assembly = null;
        private string classname = string.Empty;
        private bool isSuccess = false;
        private string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";
        private object obj = null;
        private Type t;

        public WebServiceHelper(string Url, string classname)
        {
            if ((classname == null) || (classname == string.Empty))
            {
                this.classname = this.GetWsClassName(Url);
            }
            else
            {
                this.classname = classname;
            }
            try
            {
                Stream stream = new WebClient().OpenRead(Url + "?WSDL");
                ServiceDescription serviceDescription = ServiceDescription.Read(stream);
                ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
                importer.AddServiceDescription(serviceDescription, "", "");
                CodeNamespace namespace2 = new CodeNamespace(this.@namespace);
                stream.Close();
                CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
                codeCompileUnit.Namespaces.Add(namespace2);
                importer.Import(namespace2, codeCompileUnit);
                ICodeCompiler compiler = new CSharpCodeProvider().CreateCompiler();
                CompilerParameters options = new CompilerParameters();
                options.GenerateExecutable = false;
                options.GenerateInMemory = true;
                options.ReferencedAssemblies.Add("System.dll");
                options.ReferencedAssemblies.Add("System.XML.dll");
                options.ReferencedAssemblies.Add("System.Web.Services.dll");
                options.ReferencedAssemblies.Add("System.Data.dll");
                CompilerResults results = compiler.CompileAssemblyFromDom(options, codeCompileUnit);
                if (results.Errors.HasErrors)
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (CompilerError error in results.Errors)
                    {
                        builder.Append(error.ToString());
                        builder.Append(Environment.NewLine);
                    }
                    throw new Exception(builder.ToString());
                }
                this.assembly = results.CompiledAssembly;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.InnerException.Message, new Exception(exception.InnerException.StackTrace));
            }
        }

        private bool CreateInstance()
        {
            try
            {
                this.t = this.assembly.GetType(this.@namespace + "." + this.classname, true, true);
                this.obj = Activator.CreateInstance(this.t);
                this.isSuccess = true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return this.isSuccess;
        }

        private string GetWsClassName(string wsUrl)
        {
            string[] strArray = wsUrl.Split(new char[] { '/' });
            return strArray[strArray.Length - 1].Split(new char[] { '.' })[0];
        }

        public object InvokeWebService(string methodanme, params object[] parms)
        {
            object obj2;
            if (!this.isSuccess)
            {
                this.CreateInstance();
            }
            try
            {
                obj2 = this.t.GetMethod(methodanme).Invoke(this.obj, parms);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.InnerException.Message, new Exception(exception.InnerException.StackTrace));
            }
            return obj2;
        }
    }
}


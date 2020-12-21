using Newtonsoft.Json;
using System;
using System.IO;

namespace KissTheCook.WPF.Helpers
{
    /// <summary>
    /// Facade class for exporting to file.
    /// Implemented as Singleton.
    /// </summary>
    public class ExportToFileFacade
    {
        private static readonly Lazy<ExportToFileFacade> _instance = new Lazy<ExportToFileFacade>(() => new ExportToFileFacade());

        public static ExportToFileFacade Instance
        {
            get { return _instance.Value; }
        }

        private ExportToFileFacade() { }

        public void ExportToJson(object @object, string destinationPath)
        {
            using (StreamWriter destinationFile = File.CreateText(destinationPath))
            {
                JsonSerializer serializer = CreatePrettyJsonSerializer();

                serializer.Serialize(destinationFile, @object);
            }
        }

        public JsonSerializer CreatePrettyJsonSerializer()
        {
            var settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;

            return JsonSerializer.Create(settings);
        }
    }
}

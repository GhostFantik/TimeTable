using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Linq;

namespace VkBot.Utils
{
    class JsonValidation
    {
        private static JsonValidation instansee;
        public static JsonValidation GetInstanse()
        {
            if (instansee == null)
                instansee = new JsonValidation();
            return instansee;
        }
        JSchemaGenerator generator = new JSchemaGenerator();
        public bool isValid(Type schemaType, string json)
        {
            JSchema schemaJson = generator.Generate(schemaType);
            JObject jObject = JObject.Parse(json);
            return jObject.IsValid(schemaJson);
        }
    }
}

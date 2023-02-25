﻿using Newtonsoft.Json;

 namespace FacePlusPlus.Utiles
{
    public static class JsonUtils
    {
        public static JsonSerializerSettings DefaultJsonSerializerSettings()
        {
            return new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ObjectCreationHandling = ObjectCreationHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }
    }
}
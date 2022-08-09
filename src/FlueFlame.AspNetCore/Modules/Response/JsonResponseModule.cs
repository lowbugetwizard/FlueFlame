using System;
using FlueFlame.AspNetCore.Deserialization;

namespace FlueFlame.AspNetCore.Modules.Response
{
    public class JsonResponseModule : FormattedResponseModule<JsonResponseModule>
    {
        private readonly string _response;

        public JsonResponseModule(FlueFlameHost application) : base(application)
        {
            ArgumentNullException.ThrowIfNull(response);
            _response = response;
            Serializer = Application.ServiceFactory.Get<IJsonSerializer>();
        }
    }
}
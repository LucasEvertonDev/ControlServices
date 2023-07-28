using ControlServices.Core.Models.Models.Base;

namespace ControlServices.Core.Models.Models.Token
{
    public class TokenModel : BaseModel
    {
        public TokenModel() { }

        public string TokenJWT { get; set; }
        public DateTime Expiration { get; set; }
    }
}

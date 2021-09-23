namespace PizzaCore.Entity.Payload
{
    public class Jwt    
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
        public string User { get; set; }

        public Jwt(string token,string exp,string user)
        {
                this.Token = token;
                this.Expiration = exp;
                this.User = user;
        }
    }
}
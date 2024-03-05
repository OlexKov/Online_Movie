namespace BusinessLogic.Helpers
{
    public class JwtOptions
    {
		public string Issuer { get; set; }
		public string Key { get; set; }
		public int AccessTokenLifeTimeMinutes { get; set; }
		public int RefreshTokenLifeTimeDays { get; set; }
	}
}
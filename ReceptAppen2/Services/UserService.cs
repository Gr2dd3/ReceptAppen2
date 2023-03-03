namespace ReceptAppen2.Services
{
    internal class UserService
    {
        internal static string Encode_User_Info_For_Api_Request_LogIn(string socialSecurityNumber, string password)
        {
            var userInfo = socialSecurityNumber + ":" + password;
            var encodedUserInfo = System.Text.Encoding.UTF8.GetBytes(userInfo);
            return System.Convert.ToBase64String(encodedUserInfo);
        }

        internal static async Task<User> GetUserAsync(string apiKey)
        {
            //    // Mattias
            //    string hardCodedUser = "ODYxMjMwMDI3MDo0ODQzMTE=";

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/login");
            request.Headers.Add("AuthenticationTicket", "BAEBB9E17176B46DE49C8ABE8D3BA686E388A32EB0295EA79FAC4F32B71ABB7CE9101B3F14F6E75F56B731FA8652A7D5A68A6F6FF161A223EFB43307D6775194613652EF7A1986E2F8D9FAB7E1A4AD212704AA1564BA5D53DACB39BD87D0F650AC0AB9A49E5E047CEC6E71C093BC640B625842B169F2111CEEA497228F64396EF8D8FDC31B06AF207B6A0C6AE4A188A832A9156A1606355AEBF67BC111570127B61BD0F2F7B37C54A6F966D3F34BB07C80E704540765283DA63AA36E815B209031850C553CCA0BDEFB76B7EDF960ECF705C4729A02FCAF4F8EBEE4CBC3CB31E66D1D6F27C6E28FDACCFFF62A69E86E45421BD7F2446D32FFD46E648D8A2F2B5E8BBD04ABD6F45C212559DD82EDF39A9993B3FDBDFF5C30A6F1130490B480374FC7DB48B5403534FE4321B1E21A29CD85363E71074B121C501E4D35AC515C2D60679CB643C9C02CCA7CD5C89B0A93B2E50B9D4E2F4BB5E6A7B9ED4FEB6023948772210A29EE73EA8D050F78DF57DC5FA5931FF57D9DD6F04744731AECFD3C0C5481AF8679B9AF832D244D2570DE198556DCE6ADE5E29C4153ED74C94360ECC52B8272C70C16EC5AFA2732CCF3959E6834BBD3E8373B8AF813FDA1294C709A7CB5370F072FBF4C2ED08EEE6095C39A053DCBA19D6F06D3FE3E125DF073D6D4C314A72527319EBE1B71A545290304C56613C1D75196F175968DF6B18C2A02E330AC6857CC3F");
            request.Headers.Add("Authorization", "Basic " + apiKey);
            request.Headers.Add("Cookie", "TS01841c8a=01f0ddaba33ba569c821fc9d67e1e50770a8159268d8a95c4d15f71109d437dda4399f3c5f7d285f63700bb141b51c34f66a399d9f");
            var content = new StringContent("", null, "text/plain");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            User user = new User();
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                user = JsonSerializer.Deserialize<User>(responseString);
            }
            return user;
        }
    }
}

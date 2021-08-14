namespace SocialOpinionAPI.DTO.Blocks
{
    public class BlockUserDTO
    {
        public string target_user_id { get; set; }
    }

    public class BlockUserResponseDTO
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public bool blocking { get; set; }
    }

}

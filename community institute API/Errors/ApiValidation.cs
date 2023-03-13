namespace community_institute_API.Errors
{
    public class ApiValidation : ApiResponse
    {
        //errors enumrble
        public IEnumerable<string> Errors { get; set; }

        
        public ApiValidation() : base(400)
        {
            

        }
    }
}

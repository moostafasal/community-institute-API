namespace community_institute_API.Errors
{
    public class ApiExptionRespons : ApiResponse
    {
        public string Details { get; set; }
        public ApiExptionRespons(int SutausCode, string Massage = null, string details = null) : base(SutausCode, Massage)
        {
            Details = details;


        }
    }
}

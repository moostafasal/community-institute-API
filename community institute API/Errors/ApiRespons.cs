namespace community_institute_API.Errors
{
    public class ApiResponse
    {
        public int StaterCode { get; set; }
        public string Massege { get; set; }

        public ApiResponse(int staterCode, string massege = null)
        {
            StaterCode = staterCode;
            Massege = massege ?? GetDefultmassegForStatusCode(StaterCode);
        }

        private string GetDefultmassegForStatusCode(int staterCode)
        {
            return StaterCode switch
            {
                400 => "BAD REQOUST TRY AGAIN :)",
                401 => "YOU ARE NOT  Authrized  ",
                404 => "Resours Not found!!!!! ",
                500 => " =>SERVER ERRor plasse wate we will back soon Dont Worrey  ",
                _ => null
                

            };
        }
    }
}

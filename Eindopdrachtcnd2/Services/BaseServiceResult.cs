namespace CampaingControlCenterAPI.Services
{
    public class BaseServiceResult<T>
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public T Data { get; set; }

        public static async Task<BaseServiceResult<T>> TryCatch(Func<Task<T>> func)
        {
            var result = new BaseServiceResult<T>();
            try
            {
                result.Data = await func();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}

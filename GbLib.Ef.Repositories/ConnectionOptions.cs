namespace GbLib.Ef.Repositories
{
    public class ConnectionOptions
    {
        // Thông tin kết nối đến server
        public string ConnString { get; set; }
        /// <summary>
        /// Nếu giá trị này = true, nó sẽ bật EnableRetryOnFailure. Trường hợp này sẽ không sử dụng được Transaction.
        /// Với data lớn trả về thì nên tắt nó tránh việc tốn bộ nhớ.
        /// </summary>
        public bool EnableRetryOnFailure { get; set; } = true;
        public int MaxRetryCount { get; set; } = 15;
        public int MaxRetryDelay { get; set; } = 30;
    }
}
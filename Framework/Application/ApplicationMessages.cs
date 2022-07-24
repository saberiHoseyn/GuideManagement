namespace Framework.Application
{
    public class ApplicationMessages
    {
        public static string DuplicatedRecord { get; private set; } = "امکان ثبت رکورد تکراری وجود ندارد٬ لطفا مجددا تکلاش کنید.";
        public static string RecordNotFound { get; private set; } = "رکوردی با اطلاعات درخواستی یافت نشد٬ لطفا مجددا تلاش فرمایید.";
        public static string RecordActivated { get; set; } = "فعال شد.";
        public static string RecordDeactivated { get; set; } = "غیر فعال شد.";
    }
}

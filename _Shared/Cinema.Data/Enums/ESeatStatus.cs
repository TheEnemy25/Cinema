namespace Cinema.Data.Enums
{
    public enum ESeatStatus
    {
        Available = 1,  // Доступне
        Occupied,    // Зайняте
        Broken,      // Пошкоджене
        Reserved,    // Заброньоване
        Cleaning,    // Прибирання
        Blocked,     // Заблоковане (наприклад, під час обслуговування)
    }
}

public class Data
{
    public int Year;
    public int Month;
    public int Day;

    public Data()
    {
        Year = 2025;
        Month = 1;
        Day = 1;
    }

    public Data(int year, int mounth, int day)
    {
        this.Year = (year >= 1 || year <= 2025) ? year : 1;
        this.Month = (mounth >= 1 || mounth <= 12) ? mounth : 1;

        int daysInMonth = DateTime.DaysInMonth(this.Year, this.Month);
        this.Day = (day >= 1 || day <= daysInMonth) ? day : 1;
    }



}

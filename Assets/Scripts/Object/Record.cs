using System;
[System.Serializable]
public class Record
{
    public int idMap;
    public int distance;
    public int kill;
    public int minute;
    public DateTime day;

    public Record () { }

    public Record (int idMap, int distance, int kill, int minute, DateTime day)
    {
        this.idMap = idMap;
        this.distance = distance;
        this.kill = kill;
        this.minute = minute;
        this.day = day;
    }
}

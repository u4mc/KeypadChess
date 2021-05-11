
public class KeyArray
{
    public Key[] keys { get; set; }
}

public class Key
{
    public string name { get; set; }
    public Coordinates coordinates { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int? id { get; set; }

    public bool doNotStart { get; set; }
    public bool doNotUse { get; set; }
}

public class Coordinates
{
    public int x { get; set; }
    public int y { get; set; }
    
}

namespace Force_Directed_Maps
{
    public struct UnID
    {
        public string ID;
        public UnID(int a, UnID b)
        {
            ID = b.ID + System.Convert.ToString(a);
        }
        public UnID(string t)
        {
            ID = t;
        }
        public int WorkLayer()
        {
            return ((ID.Trim()).Length - 1) / 2;
        }
    }
}

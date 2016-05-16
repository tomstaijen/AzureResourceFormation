namespace Azure.Model.Syntax
{
    public class Location
    {
        public string Name { get; set; }

        public static implicit operator Location(string loc)  // explicit byte to digit conversion operator
        {
            return new Location()
            {
                Name = loc
            };
        }
    }
}
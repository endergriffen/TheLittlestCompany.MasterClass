using System.Reflection;

namespace TheLittlestCompany.MasterClass.Furniture.Terminal_Patch
{
    public static class Terminal_Reflection_Extensions
    {
        public static T2 GetField<T, T2>(this T obj, string name)
        {
            return (T2)obj.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField).GetValue(obj);
        }
    }
}
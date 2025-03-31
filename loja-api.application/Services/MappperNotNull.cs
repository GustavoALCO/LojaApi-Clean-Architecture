namespace loja_api.application.Services;

public class MappperNotNull
{
    public static bool IsValidValue(object? srcMember)
    {
        if(srcMember == null)
            return false;

        return srcMember switch
        {
            int i => i != 0,
            long l => l != 0,
            double d => d != 0.0,
            float f => f != 0.0f,
            string s => !string.IsNullOrWhiteSpace(s),
            List<object> collection => collection.Count > 1, // Ignora listas vazias
            _ => true
        };
    }
}

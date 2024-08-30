namespace LinkEcommerce.ServiceDefaults.Contexts;

public class AppSpecificationEvaluator : SpecificationEvaluator
{
    public static AppSpecificationEvaluator Instance { get; } = new AppSpecificationEvaluator();

    public AppSpecificationEvaluator() : base()
    {
        Evaluators.Add(QueryTagEvaluator.Instance);
    }
}
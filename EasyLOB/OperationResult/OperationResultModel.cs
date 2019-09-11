namespace EasyLOB
{
    public class OperationResultModel
    {
        public ZOperationResult OperationResult { get; set; }

        public OperationResultModel()
        {
            OperationResult = new ZOperationResult();
        }

        public OperationResultModel(ZOperationResult operationResult)
        {
            OperationResult = operationResult;
        }
    }
}
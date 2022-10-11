namespace Expenses.Domain.Options
{
    public enum TransactionMethod : ushort
    {
        //Incasso
        Collection = 1,
        //Online bankieren
        OnlineBanking = 2,
        //Betaalautomaat
        PayTerminal = 3,
        //GeldAutomaat
        ATM = 4,
        //Overschrijving
        Transfer = 5,
        //Verzamelbetaling
        CollectivePayment = 6,
        //IDEAL
        Ideal = 7,
        //Diversen
        Others = 99
    }
}

using Firebase.Firestore;

[FirestoreData]
public class User
{
    [FirestoreProperty]
    public string country { get; set; }

    [FirestoreProperty]
    public string email { get; set; }

    [FirestoreProperty]
    public string lastName { get; set; }

    [FirestoreProperty]
    public string firstName { get; set; }

    [FirestoreProperty]
    public string phoneNumber { get; set; }

    /*Phone numbers cannot be integers because phone numbers can exceed the limit of numerical variables like: int or even long
     * you can follow up more here:
     * https://stackoverflow.com/questions/42255754/phone-number-should-be-a-string-or-some-numeric-type-that-have-capacity-to-save/42255861
     */
}
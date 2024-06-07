using System.Transactions;
using Sqids;

var sqids = new SqidsEncoder<int>(new()
{
    //Use https://sqids.org/playground for generating new alphabet
    Alphabet = "zWGMZdJxkbp4wsy08qICanhcg9XQY1vOAuofF53jVSLKTNm7Ei2Uet6lrRDHPB",
    MinLength = 5,
});

var db = new List<Customer>
{
    new Customer(1, "Anet Bucksey", "abucksey0[at]apache.org", "8515 Dwight Place", "Recruiting Manager"),
    new Customer(2, "Corabelle Downage", "cdownage1[at]google.co.jp", "663 Eastwood Alley", "Registered Nurse"),
    new Customer(3, "Odell Lenin", "olenin2[at]fema.gov", "10 Golf Course Hill", "Operator"),
    new Customer(4, "Catriona Sargant", "csargant3[at]china.com.cn", "9540 Golf Course Street", "Recruiter"),
    new Customer(5, "Livvie Lindgren", "llindgren4[at]reverbnation.com", "8507 Washington Center", "Professor"),
    new Customer(6, "Emelen Meron", "emeron5[at]bravesites.com", "4 Chinook Avenue", "Pharmacist"),
    new Customer(7, "Kingsley Goozee", "kgoozee6[at]thetimes.co.uk", "47 Heath Lane", "Administrative Assistant IV"),
    new Customer(8, "Magdalen Wilmot", "mwilmot7[at]i2i.jp", "9328 Toban Way", "VP Sales"),
    new Customer(9, "Josy Flury", "jflury8[at]sbwire.com", "44261 Pepper Wood Crossing", "Editor"),
    new Customer(10, "Ursulina Prinn", "uprinn9[at]cdc.gov", "54219 Pierstorff Drive", "Dental Hygienist"),
};

foreach (var customer in db)
{
    Console.WriteLine($"Id: {sqids.Encode(customer.Id)}, Name: {customer.Name}");
}

while (true)
{
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine("Press ctrl+c to exit,");
    Console.Write("Enter an Id: ");

    var idToLookup = Console.ReadLine();
    int decodedId = sqids.Decode(idToLookup).Single();

    //Re encode the decoded sqid for assuring canonical id
    if (idToLookup == sqids.Encode(decodedId))
    {
        var customer = db.FirstOrDefault(c => c.Id == sqids.Decode(idToLookup).FirstOrDefault());

        if (customer != null)
        {
            Console.WriteLine($"Id: {customer.Id}, Name: {customer.Name}");
        }
    }
    else
    {
        Console.WriteLine("Not valid sqid");
    }
}

public record Customer(int Id, string Name, string Email, string Address, string JobRole);
using Azure.Storage.Sas;

namespace PosTechFiapImagensWebApi.Factory;

public class BlobSasBuilderFactory
{
    public static BlobSasBuilder CreateBlobSasBuilder(string conteinerName, string blobName)
    {
        BlobSasBuilder sasBuilder = new()
        {
            BlobContainerName = conteinerName,
            BlobName = blobName,
            Resource = "b",
            StartsOn = DateTime.UtcNow.AddMinutes(-15),
            ExpiresOn = DateTime.UtcNow.AddMinutes(45),
            Protocol = SasProtocol.Https
        };

        sasBuilder.SetPermissions(BlobAccountSasPermissions.Read);
        return sasBuilder;
    }
}
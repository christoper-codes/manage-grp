using manage_grp.Server.DTOs.External;

public class DipomexApiResponse
{
    public bool Error { get; set; }
    public string Message { get; set; }
    public IEnumerable<StateDipomexDto>? Estados { get; set; }

    public IEnumerable<MunicipalityDipomexDto>? Municipios { get; set; }
}

using shardymapy.Models.Anaquel;

namespace shardymapy.Dto;

public class AnaquelConfigDto
{
        
        public AnaquelLineaVistaSuperiorConfiguracion? SuperiorConfiguration{get;set;}
        public AnaquelLineaVistaFrontalConfiguration? FrontalConfiguration{get;set;}
        public IEnumerable<AnaquelLineaVistaSuperiorConfiguracion>? SuperiorConfigurations{get;set;}
        public IEnumerable<AnaquelLineaVistaFrontalConfiguration>? FrontalConfigurations{get;set;}
    

}
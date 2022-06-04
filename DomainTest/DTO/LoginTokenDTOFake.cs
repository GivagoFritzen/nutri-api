using Domain.DTO.Token;

namespace DomainTest.DTO
{
    public static class LoginTokenDTOFake
    {
        public static LoginTokenDTO GetFake()
        {
            return new LoginTokenDTO()
            {
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InN0cmluZyIsImVtYWlsIjoibnV0cmlAdGVzdGUuY29tIiwicHJpbWFyeXNpZCI6IjZjZTg2NTI2LTZhMjctNDcwMy1hNGFlLTUwZDdiNTBiOGE3YSIsInJvbGUiOiJOdXRyaWNpb25pc3RhIiwibmJmIjoxNjUzODU5MTM5LCJleHAiOjE2NTM4NjYyMzIsImlhdCI6MTY1Mzg1OTEzOX0.NIt_dKfu0-VWNJ3T4YlOwO14GgYpoEiEhVUbS8u-5Uk",
                RefreshToken = "ySm98/fUvggqyWj5S6YXaJEwnDPjMuyOKd3bUrV85Ds="
            };
        }
    }
}

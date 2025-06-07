using NBomber.CSharp;

using var httpClient = new HttpClient
{
    BaseAddress = new Uri("http://localhost:8080")
};

httpClient.DefaultRequestHeaders.Authorization =
    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI2OGE2N2I1Mi1jZjc3LTQwY2ItYjk0Yy05MTAyYjlmOGZlOTYiLCJ1bmlxdWVfbmFtZSI6ImFkbWluQGdtYWlsLmNvbSIsImVtYWlsIjoiYWRtaW5AZ21haWwuY29tIiwicm9sZSI6IkFkbWluaXN0cmF0b3IiLCJuYmYiOjE3NDkzMzE4ODMsImV4cCI6MTc4MDg2Nzg4MywiaWF0IjoxNzQ5MzMxODgzLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAifQ.5HRHfyzSmPy3NzDglYQdmRCtSOb-M413jwuNpV0lRe0");

var scenario = Scenario.Create("GET /api/medicine", async context =>
{
    var response = await httpClient.GetAsync("/api/medicine");

    return response.IsSuccessStatusCode
        ? Response.Ok()
        : Response.Fail();
})
.WithWarmUpDuration(TimeSpan.FromSeconds(5))
.WithLoadSimulations(Simulation.KeepConstant(copies: 50, during: TimeSpan.FromSeconds(15)));

NBomberRunner
    .RegisterScenarios(scenario)
    .Run();

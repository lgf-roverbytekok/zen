using UnityEngine;

namespace Zen
{
    public class GraphQLSample : MonoBehaviour
    {
        async void Start()
        {
            var variables = new GraphQL.Types.AuthLoginInput
            {
                username = "zen",
                password = "TempTemp",
                rememberMe = true
            };

            var request = GraphQL.AuthLoginSampleGQL.Request(new { data = variables });

            try
            {
                var response = await NetworkManager.SendGraphQLRequest<GraphQL.AuthLoginSampleResponse>(request);
                Debug.Log("AuthLoginSampleGQL user: " + response.data.authLogin.userId);
            }
            catch (GraphQLError err)
            {
                Debug.LogError("GraphQL error: " + err.message);
            }
        }
    }
}

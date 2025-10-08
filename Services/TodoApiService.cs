using System.Text.Json;
using MyResumeSite.Models;

namespace MyResumeSite.Services
{
    /// <summary>
    /// Service for consuming the JSONPlaceholder Todos API
    /// </summary>
    public class TodoApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TodoApiService> _logger;
        private readonly JsonSerializerOptions _jsonOptions;

        public TodoApiService(HttpClient httpClient, ILogger<TodoApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            
            // Configure JSON serialization options
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        /// <summary>
        /// Fetches all todo items from the JSONPlaceholder API
        /// </summary>
        /// <returns>A list of TodoItem objects, or empty list if API call fails</returns>
        public async Task<List<TodoItem>> GetTodosAsync()
        {
            try
            {
                _logger.LogInformation("Fetching todos from API...");
                
                var response = await _httpClient.GetAsync("todos");
                response.EnsureSuccessStatusCode();
                
                var jsonContent = await response.Content.ReadAsStringAsync();
                var todos = JsonSerializer.Deserialize<List<TodoItem>>(jsonContent, _jsonOptions);
                
                _logger.LogInformation("Successfully fetched {Count} todos", todos?.Count ?? 0);
                
                return todos ?? new List<TodoItem>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed when fetching todos");
                throw;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize JSON response");
                throw;
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogError(ex, "Request timeout when fetching todos");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error when fetching todos");
                throw;
            }
        }
    }
}

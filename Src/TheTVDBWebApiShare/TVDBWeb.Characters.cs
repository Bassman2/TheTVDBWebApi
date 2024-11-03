namespace TheTVDBWebApi
{
    public partial class TVDBWeb
    {
        /// <summary>
        /// Returns character base record.
        /// </summary>
        /// <param name="id">Id of the character base record.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Character base record.</returns>
        public async Task<Character?> GetCharacterAsync(long id, CancellationToken cancellationToken = default)
        {
            return await GetFromJsonAsync<Character>($"v4/characters/{id}", cancellationToken);
        }
    }
}

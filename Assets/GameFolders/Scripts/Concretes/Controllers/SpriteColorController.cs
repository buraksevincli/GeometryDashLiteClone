using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class SpriteColorController : MonoBehaviour
    {
        [SerializeField] private Color[] colors;
        [SerializeField] private float cycleDuration;

        private SpriteRenderer _spriteRenderer;
        private float _counter;
        private int _currentColorIndex;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = colors[_currentColorIndex];
        }

        private void Update()
        {
            _counter += Time.deltaTime;

            if (_counter >= cycleDuration)
            {
                _counter = 0f;

                _currentColorIndex = (_currentColorIndex + 1) % colors.Length;
            }
            
            Color currentColor = colors[_currentColorIndex];
            Color nextColor = colors[(_currentColorIndex + 1) % colors.Length];
            
            _spriteRenderer.color = Color.Lerp(currentColor, nextColor, _counter / cycleDuration);
        }
    }
}

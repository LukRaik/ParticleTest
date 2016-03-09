using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleTest
{
    class Particle
    {
        private Texture2D _texture;
        Vector2 _ruch;
        Vector2 _origin;
        private Vector2 _pos;
        private float _rotation;
        private float _scale;
        private SpriteEffects _efekt;
        float _alpha;
        private int _ttl;
        private float _tl;
        public event EventHandler Event_Usun;
        public bool _rotate;
        public float _rotate_jump;
        public Particle(Texture2D txt, Vector2 pos, Vector2 ruch, int _TimeToLive,bool rotation)
        {
            _texture = txt;
            _pos = pos;
            _scale = 1;
            _rotation = 0;
            _ruch = ruch;
            _alpha = 1.0f;
            _ttl = _TimeToLive;
            _tl = 0;
            _rotate = rotation;
            _rotate_jump = 0.5f;
            _origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        }
        public void Update(GameTime gameTime)
        {
            _tl += gameTime.ElapsedGameTime.Milliseconds*0.001f;
            
            _alpha = 1-(_tl / _ttl);

            if (_tl > _ttl)
            {
                Event_Usun(this, null);
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _pos, null, Color.White * _alpha, _rotation, _origin, _scale, _efekt, 0);
            if (_rotate) _rotation += _rotate_jump;
            _pos.X += _ruch.X;
            _pos.Y += _ruch.Y;
        }
    }
}

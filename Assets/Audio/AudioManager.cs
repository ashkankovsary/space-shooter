using NAudio.Wave;
using System;
using System.IO;

namespace Space_Shooter_game
{
    public static class Sounds
    {
        public const string MusicWave1To9 = "bg_wave1_9.mp3";
        public const string MusicWave10 = "bg_wave10.mp3";
        public const string EnemyBulletHit = "sfx_enemy_bullet_hit.mp3";
        public const string PlayerBulletHit = "sfx_player_bullet_hit.mp3";
        public const string ShipCollision = "sfx_ship_collision.mp3";
        public const string EnemyDestroyed = "sfx_enemy_destroyed.mp3";
        public const string PowerUpPickup = "sfx_powerup_pickup.mp3";
        public const string CoinDrop = "sfx_coin_drop.mp3";
        public const string HealthPackUse = "sfx_health_pack_use.mp3";
        public const string ClickButton = "sfx_click_button.mp3";
    }
    public static class AudioManager
    {
        private static WaveOutEvent musicOutput;
        private static AudioFileReader musicReader;
        public static bool music = true;
        public static bool sfx = true;

        public static float MusicVolume = 0.2f;
        public static float SfxVolume = 0.2f;

        private static string GetPath(string fileName) =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Audio", fileName);

        public static void PlayMusic(string fileName, bool loop = true)
        {
            if(!music) { return; }
            StopMusic();

            musicReader = new AudioFileReader(GetPath(fileName)) { Volume = MusicVolume };
            musicOutput = new WaveOutEvent();
            musicOutput.Init(musicReader);

            if (loop)
            {
                musicOutput.PlaybackStopped += MusicOutput_PlaybackStopped;
            }
            musicOutput.Play();
        }

        private static void MusicOutput_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (musicReader == null || musicOutput == null) return;
            musicReader.Position = 0;
            musicOutput.Play();
        }

        public static void StopMusic()
        {
            if (musicOutput != null)
            {
                musicOutput.PlaybackStopped -= MusicOutput_PlaybackStopped;
                musicOutput.Stop();
                musicOutput.Dispose();
            }
            musicReader?.Dispose();
            musicOutput = null;
            musicReader = null;
        }

        public static void PlaySfx(string fileName)
        {
            if(!sfx) { return; }
            var reader = new AudioFileReader(GetPath(fileName)) { Volume = SfxVolume };
            var output = new WaveOutEvent();
            output.Init(reader);
            output.PlaybackStopped += (s, e) =>
            {
                output.Dispose();
                reader.Dispose();
            };
            output.Play();
        }
    }
}
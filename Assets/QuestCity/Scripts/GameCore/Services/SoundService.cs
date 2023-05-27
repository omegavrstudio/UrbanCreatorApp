using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestCity.GameCore.Interfaces;
using QuestCity.GameCore.Base;
using QuestCity.GameCore.Structures;
using UnityEngine.Pool;

namespace QuestCity.GameCore.Services
{
    public class SoundService : ServiceBase, ISoundService
    {
        [SerializeField] private List<Sound> sounds = new List<Sound>();

        public void PlayAudio(int soundNumber)
        {
            StartCoroutine(PlayAudioClip(sounds[soundNumber].clip));
        }

        public void PlayAudio(string name)
        {
            for (int i = 0; i < sounds.Count; i++)
            {
                if (sounds[i].name == name) {
                    StartCoroutine(PlayAudioClip(sounds[i].clip));
                    return;
                }
            }
        }

		public void PlayAudio(AudioClip clip)
		{
			StartCoroutine(PlayAudioClip(clip));
		}

		IEnumerator PlayAudioClip(AudioClip clip) {

            AudioSource source = Pool.Get();
            source.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length);
            Pool.Release(source);

        }

        public enum PoolType
        {
            Stack,
            LinkedList
        }

        public PoolType poolType;


        public bool collectionChecks = true;
        public int maxPoolSize = 10;

        IObjectPool<AudioSource> m_Pool;

        public IObjectPool<AudioSource> Pool
        {
            get
            {
                if (m_Pool == null)
                {
                    if (poolType == PoolType.Stack)
                        m_Pool = new ObjectPool<AudioSource>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
                    else
                        m_Pool = new LinkedPool<AudioSource>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
                }
                return m_Pool;
            }
        }

        AudioSource CreatePooledItem()
        {
            var go = new GameObject("[AudioSource]");
            go.transform.SetParent(gameObject.transform);

            var ps = go.AddComponent<AudioSource>();

            ps.Stop();

            var returnToPool = go.AddComponent<ItemPoolAudioSource>();
            returnToPool.pool = Pool;

            return ps;
        }

 
        void OnReturnedToPool(AudioSource source)
        {
            source.gameObject.SetActive(false);
        }

        void OnTakeFromPool(AudioSource source)
        {
            source.gameObject.SetActive(true);
        }

        void OnDestroyPoolObject(AudioSource source)
        {
            Destroy(source.gameObject);
        }

	}

    [RequireComponent(typeof(AudioSource))]
    public class ItemPoolAudioSource : MonoBehaviour
    {
        public AudioSource source;
        public IObjectPool<AudioSource> pool;

        void Start() => source = GetComponent<AudioSource>();
        void OnParticleSystemStopped() => pool.Release(source);

    }

}
# No leviathans (Or any other Creature)

If you want to remove all [leviathans class organisms](https://subnautica.fandom.com/wiki/Leviathan_Class_Organisms), this file is for you.

## Instalation
It's simpel to install you open your ```subnautica``` folder, then go to the ```Subnautica_Data```, and finally go to ```Managed```. Replace the already existing dll, with the one you downloaded. Restart subnautica and enjoy.


## Custom Creatures
This is a bit more complecated. Download the original file (or use the one in your subnautica folder) and download [dnspy](https://dnspy.co/download/).

Then you need to open dnspy. If oyu have dnspy open, you press ```CTRL + o``` and then select the ```Assembly-CSharp.dll``` from your subnautica folder (or the one you downloaded). 

The next step is to enter in the Search label ```Creature``` (see picture). You then need to select the first ```Creature``` you find (be sure it has a capital ```C```)

![Creature Search](./tmp/creature.png)


Then double click on that one. Now you need to look at this ```   public virtual void Start()```, it's on line 72. You need to right click that text. And select ```Edit Method (C#)...```.


You want to select all and replace it with this.
```c#
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoBuf;
using UnityEngine;
using UWE;

// Token: 0x02000176 RID: 374
[RequireComponent(typeof(Rigidbody))]
[ProtoContract]
[ProtoInclude(1000, typeof(BloomCreature))]
[ProtoInclude(1200, typeof(Boomerang))]
[ProtoInclude(1300, typeof(LavaLarva))]
[ProtoInclude(1400, typeof(OculusFish))]
[ProtoInclude(1500, typeof(Eyeye))]
[ProtoInclude(1600, typeof(Garryfish))]
[ProtoInclude(1700, typeof(GasoPod))]
[ProtoInclude(1800, typeof(Grabcrab))]
[ProtoInclude(1900, typeof(Grower))]
[ProtoInclude(2000, typeof(Holefish))]
[ProtoInclude(2100, typeof(Hoverfish))]
[ProtoInclude(2200, typeof(Jellyray))]
[ProtoInclude(2300, typeof(Jumper))]
[ProtoInclude(2400, typeof(Peeper))]
[ProtoInclude(2500, typeof(RabbitRay))]
[ProtoInclude(2600, typeof(Reefback))]
[ProtoInclude(2700, typeof(Reginald))]
[ProtoInclude(2800, typeof(SandShark))]
[ProtoInclude(2900, typeof(Spadefish))]
[ProtoInclude(3000, typeof(Stalker))]
[ProtoInclude(3100, typeof(Bladderfish))]
[ProtoInclude(3200, typeof(Hoopfish))]
[ProtoInclude(3300, typeof(Mesmer))]
[ProtoInclude(3400, typeof(Bleeder))]
[ProtoInclude(3500, typeof(Slime))]
[ProtoInclude(3600, typeof(Crash))]
[ProtoInclude(3700, typeof(BoneShark))]
[ProtoInclude(3800, typeof(CuteFish))]
[ProtoInclude(3900, typeof(Leviathan))]
[ProtoInclude(4000, typeof(ReaperLeviathan))]
[ProtoInclude(4100, typeof(CaveCrawler))]
[ProtoInclude(4200, typeof(BirdBehaviour))]
[ProtoInclude(4400, typeof(Biter))]
[ProtoInclude(4500, typeof(Shocker))]
[ProtoInclude(4600, typeof(CrabSnake))]
[ProtoInclude(4700, typeof(SpineEel))]
[ProtoInclude(4800, typeof(SeaTreader))]
[ProtoInclude(4900, typeof(CrabSquid))]
[ProtoInclude(4910, typeof(Warper))]
[ProtoInclude(4920, typeof(LavaLizard))]
[ProtoInclude(5000, typeof(SeaDragon))]
[ProtoInclude(5100, typeof(GhostRay))]
[ProtoInclude(5200, typeof(SeaEmperorBaby))]
[ProtoInclude(5300, typeof(GhostLeviathan))]
[ProtoInclude(5400, typeof(SeaEmperorJuvenile))]
[ProtoInclude(5500, typeof(GhostLeviatanVoid))]
[RequireComponent(typeof(CreatureUtils))]
[DisallowMultipleComponent]
public partial class Creature : Living, IProtoEventListener, IScheduledUpdateBehaviour, IManagedBehaviour, ICompileTimeCheckable, IMovementPlatform
{
	// Token: 0x060009E1 RID: 2529 RVA: 0x0006E274 File Offset: 0x0006C474
	public virtual void Start()
	{
		string name = base.GetType().Name;
		if (__________)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		if (this.initialCuriosity != null && this.initialCuriosity.length > 0)
		{
			this.Curiosity.Value = this.initialCuriosity.Evaluate(UnityEngine.Random.value);
		}
		if (this.initialFriendliness != null && this.initialFriendliness.length > 0)
		{
			this.Friendliness.Value = this.initialFriendliness.Evaluate(UnityEngine.Random.value);
		}
		if (this.initialHunger != null && this.initialHunger.length > 0)
		{
			this.Hunger.Value = this.initialHunger.Evaluate(UnityEngine.Random.value);
		}
		bool flag = !this.isInitialized && this.Size < 0f;
		float magnitude = (base.transform.localScale - Vector3.one).magnitude;
		if (flag && !global::Utils.NearlyEqual(magnitude, 0f, 1E-45f))
		{
			base.transform.localScale = Vector3.one;
		}
		GrowMixin component = base.gameObject.GetComponent<GrowMixin>();
		if (component)
		{
			component.growScalarChanged.AddHandler(base.gameObject, new Event<float>.HandleFunction(this.OnGrowChanged));
		}
		else if (flag && this.sizeDistribution != null)
		{
			float size = Mathf.Clamp01(this.sizeDistribution.Evaluate(UnityEngine.Random.value));
			this.SetSize(size);
		}
		TechType techType = CraftData.GetTechType(base.gameObject);
		if (techType != TechType.None)
		{
			this.techTypeHash = UWE.Utils.SDBMHash(techType.AsString(false));
		}
		else
		{
			Debug.LogErrorFormat("Creature: Couldn't find tech type for creature name: {0}", new object[]
			{
				base.gameObject.name
			});
		}
		this.ScanCreatureActions();
		if (this.isInitialized)
		{
			this.InitializeAgain();
		}
		else
		{
			this.InitializeOnce();
			this.isInitialized = true;
		}
		DeferredSchedulerUtils.Schedule(this);
	}
}

```

If you've done that go to ```line 65``` and change ```__________``` to ```name == "ReaperLeviathan"``` with the name of the mob you want to remove. if you have a second mob you want to remove change it to this ```name == "ReaperLeviathan" || name == "GhostLeviathan"``` you can do this as often as you'd like


### How to get the name of mobs

To get
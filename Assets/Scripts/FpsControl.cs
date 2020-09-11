using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsControl : MonoBehaviour {
	//记得现在项目设置里关掉垂直同步
	public Rect screenPos;//fps 显示的坐标位置

	private float lastUpdateTime = 0f;//上次update的真实时间
	private float updateDeltaTimeIdealValue = 1f / 60f;//更新帧率的理想时间间隔
	private float updateDeltaTimeRealValue;//真实的更新帧率时间间隔
	private int frameUpdates = 0;// 帧累计的数量
	private float fps = 0f;//每秒帧数

	private void Awake() {
		Time.fixedDeltaTime = 1f / 60f;//设置fixedDeltaTime 更新速率
		QualitySettings.vSyncCount = 1;//同步帧率到显示器刷新率
		Application.targetFrameRate = 60;//限定游戏帧率
	}

	// Start is called before the first frame update
	void Start() {
		lastUpdateTime = Time.realtimeSinceStartup;
	}

	// Update is called once per frame
	void Update() {
		frameUpdates++;
		updateDeltaTimeRealValue = Time.realtimeSinceStartup - lastUpdateTime;
		if(updateDeltaTimeRealValue >= updateDeltaTimeIdealValue) {
			fps = frameUpdates / updateDeltaTimeRealValue;
			frameUpdates = 0;
			lastUpdateTime = Time.realtimeSinceStartup;
		}
	}

	private void OnGUI() {
		GUI.Label(screenPos, "FPS:" + fps);
		//GUI.Label(new Rect(Screen.width / 2, 0, 100, 100), "FPS:" + fps);
	}

}

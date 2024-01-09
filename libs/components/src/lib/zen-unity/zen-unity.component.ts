import { AfterViewInit, Component, ElementRef, OnDestroy, ViewChild } from '@angular/core';

declare const createUnityInstance: any;

@Component({
  selector: 'zen-unity',
  templateUrl: 'zen-unity.component.html',
  standalone: true,
})
export class ZenUnityComponent implements AfterViewInit, OnDestroy {
  @ViewChild('unityCanvas') unityCanvas!: ElementRef<HTMLCanvasElement>;
  unityInstance: any;

  ngAfterViewInit() {
    this.load();
  }

  load = () => {
    const buildUrl = 'assets/unity/Build';
    const loaderUrl = buildUrl + '/zen-unity.loader.js';
    const config = {
      dataUrl: buildUrl + '/zen-unity.data',
      frameworkUrl: buildUrl + '/zen-unity.framework.js',
      codeUrl: buildUrl + '/zen-unity.wasm',
      streamingAssetsUrl: 'assets/unity/StreamingAssets',
      companyName: 'DefaultCompany',
      productName: 'zen-unity',
      productVersion: '0.1.0',
      showBanner: () => {
        console.log('showBanner called');
      },
    };

    const script = document.createElement('script');
    script.src = loaderUrl;
    script.onload = () => {
      createUnityInstance(this.unityCanvas.nativeElement, config, () => {
        // progressBarFull.style.width = 100 * progress + '%';
      })
        .then((unityInstance: any) => {
          this.unityInstance = unityInstance;
          // loadingBar.style.display = 'none';
          // fullscreenButton.onclick = () => {
          //   unityInstance.SetFullscreen(1);
          // };
          console.log('DONE LOADING');
        })
        .catch((message: string) => {
          alert(message);
        });
    };

    document.body.appendChild(script);
  };

  ngOnDestroy(): void {
    try {
      this.unityInstance?.Quit();
    } catch (error) {
      console.error(error);
    }
  }
}

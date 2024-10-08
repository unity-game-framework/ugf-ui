# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0](https://github.com/unity-game-framework/ugf-ui/releases/tag/2.0.0) - 2024-08-09  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-ui/milestone/8?closed=1)

## [2.0.0-preview.5](https://github.com/unity-game-framework/ugf-ui/releases/tag/2.0.0-preview.5) - 2024-05-29  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-ui/milestone/7?closed=1)  
    

### Fixed

- Fix virtual scroll world rect check ([#18](https://github.com/unity-game-framework/ugf-ui/issues/18))  
    - Update dependencies: `com.ugf.editortools` to `3.0.0-preview.9` version.
    - Fix `LayoutGroupVirtualScrollComponent.Calculate()` method to properly check for culling of children.

## [2.0.0-preview.4](https://github.com/unity-game-framework/ugf-ui/releases/tag/2.0.0-preview.4) - 2024-04-02  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-ui/milestone/6?closed=1)  
    

### Added

- Add layout fit in parent components ([#16](https://github.com/unity-game-framework/ugf-ui/issues/16))  
    - Update dependencies: `com.ugf.editortools` to `3.0.0-preview.6` version.
    - Add `LayoutFitInParentComponent` and `LayoutFitInParentImageComponent` classes as layout components to calculate position to fit inside a parent.

## [2.0.0-preview.3](https://github.com/unity-game-framework/ugf-ui/releases/tag/2.0.0-preview.3) - 2024-02-22  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-ui/milestone/5?closed=1)  
    

### Added

- Add group virtual scroll generic with handler arguments ([#14](https://github.com/unity-game-framework/ugf-ui/issues/14))  
    - Add `ILayoutGroupVirtualScrollConstructor` interface as abstract scroll items constructor.
    - Add `LayoutGroupVirtualScrollConstructorHandlers` and `LayoutGroupVirtualScrollConstructorHandlers<T>` classes as default implementation of scroll items construction.
    - Change `LayoutGroupVirtualScrollComponent` class to work using instance of `ILayoutGroupVirtualScrollConstructor` interface.

## [2.0.0-preview.2](https://github.com/unity-game-framework/ugf-ui/releases/tag/2.0.0-preview.2) - 2023-11-25  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-ui/milestone/4?closed=1)  
    

### Added

- Add layout virtual scroll component ([#12](https://github.com/unity-game-framework/ugf-ui/issues/12))  
    - Update dependencies: add `com.ugf.runtimetools` of `3.0.0-preview` version.
    - Add `LayoutGroupVirtualScrollComponent` class as component to implement virtual layout inside scroll rect.

## [2.0.0-preview.1](https://github.com/unity-game-framework/ugf-ui/releases/tag/2.0.0-preview.1) - 2023-11-23  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-ui/milestone/3?closed=1)  
    

### Fixed

- Fix components menu order value ([#10](https://github.com/unity-game-framework/ugf-ui/issues/10))  
    - Fix `LayoutCollectionComponent`, `LayoutGroupComponent`, `LayoutGroupVirtualComponent` and `LayoutTextComponent` classes with proper order value for component menu attributes.

## [2.0.0-preview](https://github.com/unity-game-framework/ugf-ui/releases/tag/2.0.0-preview) - 2023-11-18  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-ui/milestone/2?closed=1)  
    

### Added

- Add rect transform utilities ([#6](https://github.com/unity-game-framework/ugf-ui/issues/6))  
    - Add `UIUtility.GetWorldRect()` and overloads to get world space _Rect_ of the _RectTransform_.
    - Add `UIUtility.SetParentAndFill()` method to set specified parent and stretch it.
- Add graphic empty component ([#5](https://github.com/unity-game-framework/ugf-ui/issues/5))  
    - Update dependencies: add `com.ugf.editortools` of `3.0.0-preview` and `com.unity.ugui` of `2.0.0` versions.
    - Update package _Unity_ version to `2023.2`.
    - Update package registry to _UPM Hub_.
    - Add `GraphicEmptyComponent` class as component to draw graphics for ray casting support only.
- Add layout components ([#4](https://github.com/unity-game-framework/ugf-ui/issues/4))  
    - Add `LayoutComponent` abstract class as base for any layout calculation implementation.
    - Add `LayoutCollectionComponent` class as collection of layouts to calculate.
    - Add `LayoutGroupComponent` class as general layout group implementation for child transforms.
    - Add `LayoutGroupVirtualComponent` class as general layout group implementation but for _Rect_ collection only.
    - Add `LayoutTextComponent` class as layout component with calculation based on target text.
    - Add `LayoutGroupUtility` class with methods to work with layout calculations.

## [1.0.1](https://github.com/unity-game-framework/ugf-ui/releases/tag/1.0.1) - 2021-10-03  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-ui/milestone/1?closed=1)  
    

### Fixed

- Fix editor assembly settings ([#3](https://github.com/unity-game-framework/ugf-ui/pull/3))  
    - Update package to _Unity_ of `2021.1` version.
    - Fix editor assembly to be included only in editor platform.
    - Change editor context menu for anchors, moved under the _Anchors_ menu.

## [1.0.0](https://github.com/unity-game-framework/ugf-ui/releases/tag/1.0.0) - 2020-10-06  

### Release Notes

- No release notes.



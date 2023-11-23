# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

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



# 🚀 Unity 專案 Git / GitHub 協作指南（修正版）

本文件是本專案標準開發流程，用於：

- 第一次下載專案
- 日常更新與推送
- 測試他人分支並覆蓋場景
- 回滾錯誤版本
- 建立穩定版本 Tag

---

# 📂 1. 第一次下載專案並在 Unity 中開啟

如果你是第一次加入專案，請使用 **Git Clone（推薦，不用 Unity Hub Clone）**

---

## ✅ Step 1：安裝 Git

下載：

https://git-scm.com/

安裝時一路 Next 即可。

---

## ✅ Step 2：取得專案 URL

在 GitHub 點：

- `Code`
- 複製 HTTPS URL

例如：

```text
https://github.com/your-team/ADHD.git
```

---

## ✅ Step 3：Clone 專案

在資料夾（例如 F:\unity）開啟終端機：

```bash
git clone https://github.com/your-team/ADHD.git
```

---

## ✅ Step 4：用 Unity 開啟

打開：

```text
Unity Hub
```

選：

```text
Add → Add project from disk
```

選資料夾：

```text
F:\unity\ADHD
```

---

## ⚠️ 如果畫面是空的

請手動開場景：

```text
CoffeeShopInteriorDAY
```

---

# 📤 2. 如何將自己的修改推上 GitHub

當你修改 Unity 專案後：

---

## Step 1：進入專案資料夾

```text
F:\unity\ADHD
```

---

## Step 2：開啟終端機

在資料夾內：

- 右鍵 → Open in Terminal / PowerShell / Git Bash

---

## Step 3：標準三行指令

```bash
# 1. 加入所有變更
git add .

# 2. 提交變更
git commit -m "修改內容說明（例：修正Book翻頁bug）"

# 3. 推送到 GitHub
git push
```

---

# 🧪 3. 載入別人更新：功能測試 → 強制覆蓋場景

當隊友更新專案，你想測試並覆蓋場景：

---

## Step 1：保底存檔（一定要做）

```bash
git add .
git commit -m "backup before merge"
```

---

## Step 2：抓最新遠端

```bash
git fetch origin
```

---

## Step 3：建立測試分支

```bash
git checkout -b test-merge origin/main
```

---

## 💡 此時可在 Unity 測試新功能

---

## Step 4：確認功能沒問題 → 強制覆蓋場景

```bash
git checkout origin/main -- Assets/CoffeeShopInteriorDAY.unity
```

---

## Step 5：加入 Git

```bash
git add Assets/CoffeeShopInteriorDAY.unity
```

---

## Step 6：提交覆蓋

```bash
git commit -m "overwrite scene with latest version"
```

---

# ↩️ 4. 測試失敗 → 回到乾淨版本

如果測試壞掉（紅字 / 場景炸掉）：

---

## Step 1：回主分支

```bash
git checkout main
```

---

## Step 2：刪除測試分支

```bash
git branch -D test-merge
```

---

# 💾 5. 建立穩定版本 Tag（保底版本）

當專案到穩定狀態：

---

## Step 1：提交目前版本

```bash
git add .
git commit -m "stable version"
```

---

## Step 2：建立 Tag

```bash
git tag -a v1.0 -m "stable build: all systems working"
```

---

## Step 3：推送 Tag

```bash
git push origin v1.0
```

---

# 🧯 Git 出問題怎麼辦

先不要亂刪：

```bash
git status
```

再問隊友或AI查錯誤訊息即可。

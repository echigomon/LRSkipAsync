using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSkipAsync
{
    public class CS_RskipAsync
    {
        #region 共有領域
        private String _wbuf;
        private Boolean _empty;
        public String Wbuf
        {
            get
            {
                return (_wbuf);
            }
            set
            {
                _wbuf = value;
                if (_wbuf == null)
                {   // 設定情報は無し？
                    _empty = true;
                }
                else
                {
                    _empty = false;
                }
            }
        }
        private char[] _trim = { ' ', '\t', '\r', '\n' };
        #endregion

        #region コンストラクタ
        public CS_RskipAsync()
        {   // コンストラクタ
            _wbuf = null;       // 設定情報無し
            _empty = true;
        }
        #endregion

        #region モジュール
        public async Task ClearAsync()
        {   // 作業領域の初期化
            _wbuf = null;       // 設定情報無し
            _empty = true;
        }

        // '14.01.07 : 評価対象に"￥ｒ"追加
        public async Task ExecAsync()
        {   // 右側余白情報を削除
            if (!_empty)
            {   // バッファーに実装有り
                _wbuf = _wbuf.TrimEnd(_trim);       // 右側余白情報を削除

                if (_wbuf.Length == 0 || _wbuf == null)
                {   // バッファー情報無し
                    await ClearAsync();           // 作業領域の初期化
                }
            }
        }

        public async Task ExecAsync(String msg)
        {   // 右側余白情報を削除
            await SetbufAsync(msg);                 // 入力内容の作業領域設定

            if (!_empty)
            {   // バッファーに実装有り
                _wbuf = _wbuf.TrimEnd(_trim);       // 右側余白情報を削除

                if (_wbuf.Length == 0 || _wbuf == null)
                {   // バッファー情報無し
                    await ClearAsync();           // 作業領域の初期化
                }
            }
        }

        private async Task SetbufAsync(String _strbuf)
        {   // [_wbuf]情報設定
            _wbuf = _strbuf;
            if (_wbuf == null)
            {   // 設定情報は無し？
                _empty = true;
            }
            else
            {
                _empty = false;
            }
        }
        #endregion
    }
}

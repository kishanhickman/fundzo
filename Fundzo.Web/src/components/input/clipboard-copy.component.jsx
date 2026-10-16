import React, { useState } from "react";
import { CopyToClipboard } from "react-copy-to-clipboard";

export default (props) => {
  const [value, setValue] = useState("My copy text");
  const [copied, setCopied] = useState(false);
  
  return (
    <div>
      <textarea
        value={value}
        onChange={(e) => {
          setValue(e.target.value);
          setCopied(false);
        }}
      />
      <section className="section">
        <CopyToClipboard
          options={{ debug: props.debug, message: "" }}
          onCopy={() => setCopied(true)}
          text={value}
        >
          <button onClick={() => setCopied(true)}>
            Copy to clipboard with onClick prop
          </button>
        </CopyToClipboard>
      </section>

      {copied ? <span className={styles.copyText}>Copied.</span> : null}
    </div>
  );
};;

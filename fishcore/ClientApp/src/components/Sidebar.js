import React from 'react';
import { AssessmentComponents } from './AssessmentComponents';


export default () => {

  return (
    <aside>
      <div className="description">You can drag these nodes to the pane on the right.</div>
      <AssessmentComponents />
    </aside>
  );
};
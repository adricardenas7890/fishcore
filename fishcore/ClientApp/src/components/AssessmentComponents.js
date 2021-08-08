import React, { Component } from 'react';

export class AssessmentComponents extends Component {

    static onDragStart = (event, nodeType) => {
        event.dataTransfer.setData('application/reactflow', nodeType);
        event.dataTransfer.effectAllowed = 'move';
    };

    constructor(props) {
        super(props);
        this.state = {
            comps: [],
            loading: true
        };        
    }

    // Initiates the Fetch
    componentDidMount() {
        this.populateAssessmentComponentData();
    }

    static renderAssessmentComponent(comps) {

        let content = comps.map((comp, index) =>
            <div className={"dndnode " + comp[2]} onDragStart={(event) => AssessmentComponents.onDragStart(event, comp[2])} draggable>
                <span>{comp[0]}</span>
            </div>
        );        

        return content;
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AssessmentComponents.renderAssessmentComponent(this.state.comps);        

        return (
            <>
                {contents}
            </>
        );
    }

    async populateAssessmentComponentData() {
        const response = await fetch('assessmentcomponent');
        const data = await response.json();

        this.setState(state => {
            const comps = data.map((item, i) => [item.Name, item.Description, item.Direction]);
            
            return {
                comps,loading:false
            };
        });

    }
}

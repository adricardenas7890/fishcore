import React, { Component } from 'react';
import DevelopmentWindow from './DevelopmentWindow';


export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <DevelopmentWindow />
            </div>
        );
    }
}

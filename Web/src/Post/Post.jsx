import React, { Component } from 'react'
import PropTypes from 'prop-types';

export class Post extends Component {
  render() {
    const { id, title, imageLink, clickCounter, uniqueClickCounter  } = this.props.post;
    return (
      <div >
          <div onClick={this.props.handleClick && this.props.handleClick.bind(this, id)}>
            <h4>{title}</h4>
            <img src={imageLink}></img>
            {this.props.shouldShowCounter &&
        <h2>
          <div>
          Clicks : {clickCounter}
          </div>
          <div>
          UniqueClick : {uniqueClickCounter}
          </div>
        </h2>
      }
        </div>
      </div>
    )
  }
}

// PropTypes
// Post.protoTypes = {
//   post: PropTypes.object.isRequired,
//   handleClick: PropTypes.func.isRequired,
// }

export default Post